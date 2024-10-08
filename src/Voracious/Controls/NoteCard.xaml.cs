﻿// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Voracious.Controls
{
    public sealed partial class NoteCard : ContentView
    {
        public NoteCard()
        {
            this.DataContextChanged += NoteCard_DataContextChanged;
            this.InitializeComponent();
        }

        private void NoteCard_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var note = DataContext as UserNoteWithTitle;
            if (note == null) return;
            uiTitle.Visibility = note.DisplayTitle ? Visibility.Visible : Visibility.Collapsed;
            uiTags.Visibility = string.IsNullOrEmpty(note.Tags) ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
