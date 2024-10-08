﻿using System.Linq;
using System.Xml.Linq;

using Voracious.EPub.Enum;

namespace Voracious.EPub.OPF;

public class OpfDocument
{
    public static class Attributes
    {
        public static readonly XName UniqueIdentifier = "unique-identifier";
        public static readonly XName Version = "version";
    }

    public string UniqueIdentifier { get; set; }
    public EpubVersionEnum EpubVersion { get; set; }
    public OpfMetadata Metadata { get; set; } = new OpfMetadata();
    public OpfManifest Manifest { get; set; } = new OpfManifest();
    public OpfSpine Spine { get; set; } = new OpfSpine();
    public OpfGuide Guide { get; set; } = new OpfGuide();

    public string FindCoverPath()
    {
        var coverMetaItem = Metadata.FindCoverMeta();
        if (coverMetaItem != null)
        {
            var item = Manifest.Items.FirstOrDefault(e => e.Id == coverMetaItem.Text);
            if (item != null)
            {
                return item.Href;
            }
        }

        var coverItem = Manifest.FindCoverItem();
        return coverItem?.Href;
    }

    public string FindAndRemoveCover()
    {
        var path = FindCoverPath();
        var meta = Metadata.FindAndDeleteCoverMeta();
        Manifest.DeleteCoverItem(meta?.Text);
        return path;
    }

    public string FindNcxPath()
    {
        string path = null;

        var ncxItem = Manifest.Items.FirstOrDefault(e => e.MediaType == "application/x-dtbncx+xml");
        if (ncxItem != null)
        {
            path = ncxItem.Href;
        }
        else
        {
            // If we can't find the toc by media-type then try to look for id of the item in the spine attributes as
            // according to http://www.idpf.org/epub/20/spec/OPF_2.0.1_draft.htm#Section2.4.1.2,
            // "The item that describes the NCX must be referenced by the spine toc attribute."

            if (!string.IsNullOrWhiteSpace(Spine.Toc))
            {
                var tocItem = Manifest.Items.FirstOrDefault(e => e.Id == Spine.Toc);
                if (tocItem != null)
                {
                    path = tocItem.Href;
                }
            }
        }

        return path;
    }

    public string FindNavPath()
    {
        var navItem = Manifest.Items.FirstOrDefault(e => e.Properties.Contains("nav"));
        return navItem?.Href;
    }
}
