﻿namespace Voracious.Reader.Controls;

/// <summary>
/// Scrollbar for the entire book; vertical hash marks show the positions of the 
/// different HTML files that make up the ebook. 
/// </summary>
public sealed partial class AllUpBookPosition : ContentView
{
    const Navigator.NavigateControlId ControlId = Navigator.NavigateControlId.AllUpBookPosition;
    AllUpBookPositionCalculations Calculations = new AllUpBookPositionCalculations();

    public AllUpBookPosition()
    {
        InitializeComponent();
    }

    public void SetSectionSizes(List<double> sectionSizes)
    {
        Calculations.SetSectionSizes(sectionSizes);
        BeenDrawn = false;
        DrawLines();
    }

    public void UpdatePosition(int htmlIndex, double percentPosition) // percentPosition is 0..100
    {
        double value = Calculations.UpdatePosition(htmlIndex, percentPosition);
        if (value < 0) return;
        uiPosition.Value = value;
        DrawLines();
    }

    private void OnPositionTapped(object sender, TappedEventArgs e)
    {
        if (uiPosition.ActualWidth < 1) return;

        var position = e.GetPosition(uiPosition);
        var xvalue = position.X / uiPosition.ActualWidth;  // should be 0..1.0
        if (!Calculations.SectionSizesOk) return;

        // Which section is it in?
        var (htmlIndex, percentPosition) = Calculations.GetPercentPosition(xvalue);
        if (htmlIndex >= 0 && percentPosition >= 0.0)
        {
            var nav = Navigator.Get();
            nav.UserNavigatedTo(ControlId, new BookLocation(htmlIndex, percentPosition));
            return;
        }
    }

    bool BeenDrawn = false;
    private void OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
        BeenDrawn = false;
        DrawLines();
    }

    private void DrawLines()
    {
        if (BeenDrawn) return;
        if (!Calculations.SectionSizesOk) return;

        BeenDrawn = true;

        var canvas = uiGridLines;
        var brush = new SolidColorBrush(Colors.Gray);
        canvas.Children.Clear();
        var lineX = Calculations.GetLines(canvas.ActualWidth);
        foreach (var x in lineX)
        {
            var line = new Line()
            {
                X1 = x,
                X2 = x,
                Y1 = 0,
                Y2 = canvas.ActualHeight,
                Stroke = brush,
                Fill = brush,
                StrokeThickness = 1.0,
            };
            canvas.Children.Add(line);
        }
    }
}
