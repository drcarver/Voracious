﻿using System.Collections.Generic;

namespace Voracious.EPub;

public class EpubChapter
{
    public string Id { get; set; }
    public string AbsolutePath { get; set; }
    public string RelativePath { get; set; }
    public string HashLocation { get; set; }
    public string Title { get; set; }

    public EpubChapter Parent { get; set; }
    public EpubChapter Previous { get; set; }
    public EpubChapter Next { get; set; }
    public List<EpubChapter> SubChapters { get; set; } = new List<EpubChapter>();

    public override string ToString()
    {
        return $"Title: {Title}, Subchapter count: {SubChapters.Count}";
    }
}
