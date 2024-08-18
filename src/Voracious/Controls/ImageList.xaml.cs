﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;

using Voracious.EbookReader;
using Voracious.EpubSharp;
using Voracious.Interface;

using Windows.Storage.Pickers;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Voracious.Controls
{
    public sealed partial class ImageList : UserControl, ISetImages
    {
        Navigator.NavigateControlId ControlId = Navigator.NavigateControlId.ImageDisplay;
        public ImageList()
        {
            this.DataContext = this;
            this.InitializeComponent();
        }
        public ObservableCollection<ImageData> Images { get; } = new ObservableCollection<ImageData>();

        List<Task> loadTasks = new List<Task>();
        public async Task SetImagesAsync(ICollection<EpubByteFile> images)
        {
            DoCloseFullSize();
            Images.Clear();
            foreach (var item in images)
            {
                var data = new ImageData()
                {
                    Name = item.FileName(),
                    Href = string.IsNullOrEmpty(item.Href) ? null : item.Href,
                    EpubImage = item
                };
                Images.Add(data);
                //await data.SetImageAsync();
                loadTasks.Add(data.SetImageAsync());
            }
            await Task.WhenAll(loadTasks.ToArray());
            //Task.WaitAll(loadTasks.ToArray());
            ;
        }

        private void DoCloseFullSize()
        {
            uiFullSizeScroll.Visibility = Visibility.Collapsed;
        }
        private void OnCloseFullSize(object sender, RoutedEventArgs e)
        {
            DoCloseFullSize();
        }

        private void OnImageTapped(object sender, TappedRoutedEventArgs e)
        {
            var data = (sender as FrameworkElement).DataContext as ImageData;
            if (data == null) return;
            uiFullSizeScroll.Visibility = Visibility.Visible;
            uiImageFullSize.DataContext = data;
        }

        private static BookLocation ToBookLocation(ImageData data)
        {
            // Some data.Name are full of @. Others are not.
            // Prefer the Href value over the Name. It seems to work better for images. 
            // // // TODO: verifying that using Href is OK: var location = new BookLocation(-1, data.Name);
            var location = new BookLocation(-1, data.Href ?? data.Name);
            var same = data.Href == data.Name ? "SAME" : "DIFFERENT";
            Logger.Log($"DBG: Image {same} name={data.Name} href={data.Href ?? "null"}");
            return location;
        }

        private void OnImageDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var data = (sender as FrameworkElement).DataContext as ImageData;
            if (data == null) return;
            var location = ToBookLocation(data);
            Navigator.Get().UserNavigatedTo(ControlId, location);
        }

        private void OnGoto(object sender, RoutedEventArgs e)
        {
            var data = uiImageFullSize.DataContext as ImageData;
            if (data == null) return;
            var location = ToBookLocation(data);
            Navigator.Get().UserNavigatedTo(ControlId, location);

        }

        private void OnImageHolding(object sender, HoldingRoutedEventArgs e)
        {
            var data = (sender as FrameworkElement).DataContext as ImageData;
            if (data == null) return;
            var location = ToBookLocation(data);
            Navigator.Get().UserNavigatedTo(ControlId, location);
        }

        private void OnNextFullSize(object sender, RoutedEventArgs e)
        {
            var delta = int.Parse((sender as FrameworkElement).Tag as string);
            var idx = GetNextIndex(uiList.SelectedIndex, delta, uiList.Items.Count);
            uiList.SelectedIndex = idx;

            // Now get the selected item
            var data = uiList.SelectedItem as ImageData;
            if (data == null) return;
            uiFullSizeScroll.Visibility = Visibility.Visible;
            uiImageFullSize.DataContext = data;
        }

        private int GetNextIndex(int currIndex, int delta, int maxIndex)
        {
            var retval = currIndex + delta;
            if (retval < 0) retval = maxIndex - 1;
            if (retval >= maxIndex) retval = 0;
            return retval;
        }

        private async void OnSaveImage(object sender, RoutedEventArgs e)
        {
            var data = uiImageFullSize.DataContext as ImageData;
            if (data == null) return;
            var location = ToBookLocation(data);
            var split = data.Name.Split(new char[] { '@' });
            var fname = split[split.Length - 1];
            var extsplit = fname.Split(new char[] { '.' });
            var ext = extsplit[extsplit.Length - 1];

            var bytes = data.EpubImage.Content;
            //BitmapImage imageSource = new BitmapImage();
            //var stream = bytes.AsBuffer().AsStream().AsRandomAccessStream();

            var fsp = new FileSavePicker()
            {
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                SuggestedFileName = fname,
            };
            fsp.FileTypeChoices.Add("Image", new List<string>() { "." + ext });
            var outfile = await fsp.PickSaveFileAsync();
            if (outfile != null)
            {
                await Windows.Storage.FileIO.WriteBytesAsync(outfile, bytes);
            }
        }
    }
}
