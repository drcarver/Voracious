﻿using System.Collections.Generic;

namespace Voracious.EPub;

public class EpubSpecialResources
{
    public EpubTextFile Ocf { get; internal set; }
    public EpubTextFile Opf { get; internal set; }
    public IList<EpubTextFile> HtmlInReadingOrder { get; internal set; } = new List<EpubTextFile>();
}
