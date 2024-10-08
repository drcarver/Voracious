﻿using System.Collections.Generic;
using System.Xml.Linq;

namespace Voracious.EPub.NCX;

public class NcxNapMap
{
    /// <summary>
    /// Populated only when an EPUB with NCX is read.
    /// </summary>
    public XElement Dom { get; set; }
    public List<NcxNavPoint> NavPoints { get; set; } = new List<NcxNavPoint>();
}
