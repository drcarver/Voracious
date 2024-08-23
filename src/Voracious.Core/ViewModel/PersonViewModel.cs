﻿using System;
using System.ComponentModel.DataAnnotations;

using CommunityToolkit.Mvvm.ComponentModel;

using Voracious.Core.Enum;
using Voracious.Core.Interface;

namespace Voracious.Core.ViewModel;

/// <summary>
/// Person can be used for Author, Illustrator, Editor, Translator, etc.
/// </summary>
public partial class PersonViewModel : ObservableObject, IPerson
{
    [ObservableProperty]
    [property: Key]
    private int id;

    [ObservableProperty]
    private string name;

    /// <summary>
    /// Aliases is stored as a series of + separated names
    /// So it could be "john Jones" or "john jones+samantha sams"
    /// Never fiddle with the value directly! Use the AddAlias to add each alias.
    /// </summary>
    [ObservableProperty]
    private string? aliases;

    [ObservableProperty]
    private int birthDate;

    [ObservableProperty]
    private int deathDate;

    [ObservableProperty]
    private string webpage;

    [ObservableProperty]
    private string fileAs;

    /// <summary>
    /// e.g. aut=author ill=illustator from id.loc.gov/vocabulary/relators.html
    /// </summary>
    [ObservableProperty]
    private RelatorEnum personType;

    public PersonViewModel()
    {
    }

    public PersonViewModel(string name, RelatorEnum personType)
    {
        Name = name;
        PersonType = personType;
    }

    public void AddAlias(string value)
    {
        if (value.Contains("+")) value = value.Replace('+', '&');
        if (string.IsNullOrEmpty(Aliases)) Aliases = value;
        else Aliases = "+" + value;
    }

    public int GetImportance()
    {
        switch (personType)
        {
            case RelatorEnum.author: return 10;
            case RelatorEnum.artist: return 20;
            case RelatorEnum.editor: return 30;
            case RelatorEnum.photographer: return 40;
            case RelatorEnum.translator: return 50;
            case RelatorEnum.illustrator: return 60;

            case RelatorEnum.adapter: return 70;
            case RelatorEnum.annotator: return 80;
            case RelatorEnum.authorOfAfterward: return 90;
            case RelatorEnum.arranger: return 100;
            case RelatorEnum.compiler: return 110;
            case RelatorEnum.composer: return 120;
            case RelatorEnum.conductor: return 130;
            case RelatorEnum.performer: return 140;
            case RelatorEnum.librettist: return 150;

            case RelatorEnum.authorOfIntroduction: return 160;
            case RelatorEnum.collaborator: return 170;
            case RelatorEnum.commentator: return 180;
            case RelatorEnum.contributor: return 190;
            case RelatorEnum.dubiousAuthor: return 200;
            case RelatorEnum.editorOfCompilation: return 210;
            case RelatorEnum.engraver: return 220;
            case RelatorEnum.other: return 230;
            case RelatorEnum.publisher: return 240;
            case RelatorEnum.researcher: return 250;
            case RelatorEnum.transcriber: return 260;
            case RelatorEnum.unknown: return 270;
            case RelatorEnum.otherError: return 280;
        }
        return 999;
    }

    /// <summary>
    /// Examples:
    /// by Samantha Jones
    /// by Samantha Jones (dubious) 1777-1810
    /// illustrated by Samantha Jones 
    /// </summary>
    public string Summary
    {
        get
        {
            var dates = "";
            if (BirthDate != -999999 && DeathDate != 999999) dates = $"{BirthDate}—{DeathDate}";
            else if (BirthDate != -999999) dates = $"{BirthDate}—";
            else if (DeathDate != 999999) dates = $"—{DeathDate}";
            string retval;
            switch (PersonType)
            {
                case RelatorEnum.adapter: retval = $"adapted by {Name}"; break;
                case RelatorEnum.annotator: retval = $"annotated by {Name}"; break;
                case RelatorEnum.arranger: retval = $"arranged by {Name}"; break;
                case RelatorEnum.artist: retval = $"{Name} (artist)"; break;
                case RelatorEnum.author: retval = $"by {Name}"; break;
                case RelatorEnum.authorOfAfterward: retval = $"afterword by {Name}"; break;
                case RelatorEnum.authorOfIntroduction: retval = $"introduction by {Name}"; break;
                case RelatorEnum.collaborator: retval = $"{Name} (collaborator)"; break;
                case RelatorEnum.commentator: retval = $"{Name} (commentator)"; break;
                case RelatorEnum.compiler: retval = $"compiled by {Name}"; break;
                case RelatorEnum.composer: retval = $"composed by {Name}"; break;
                case RelatorEnum.conductor: retval = $"conducted by {Name}"; break;
                case RelatorEnum.contributor: retval = $"{Name} (contributor)"; break;
                case RelatorEnum.dubiousAuthor: retval = $"by {Name} (dubious)"; break;
                case RelatorEnum.editor: retval = $"edited by {Name}"; break;
                case RelatorEnum.editorOfCompilation: retval = $"edited by {Name} (compilation)"; break;
                case RelatorEnum.engraver: retval = $"engraved by {Name}"; break;
                case RelatorEnum.illustrator: retval = $"illustrated by {Name}"; break;
                case RelatorEnum.librettist: retval = $"{Name} (librettist)"; break;
                case RelatorEnum.otherError: retval = $"{Name}"; break;
                case RelatorEnum.performer: retval = $"performed by {Name}"; break;
                case RelatorEnum.photographer: retval = $"{Name} (photographer)"; break;
                case RelatorEnum.publisher: retval = $"published by {Name}"; break;
                case RelatorEnum.researcher: retval = $"{Name} (researcher)"; break;
                case RelatorEnum.transcriber: retval = $"transcribed by {Name}"; break;
                case RelatorEnum.translator: retval = $"translated by {Name}"; break;
                case RelatorEnum.unknown: retval = $"{Name}"; break;
                default: retval = $"{Name}"; break;
            }
            if (dates != "") retval = retval + " " + dates;
            if (Aliases != "") retval += $" ({Aliases})";
            return retval;
        }
    }

    public Uri WebpageUri
    {
        get
        {

            try
            {
                // Some web pages are malformed e.g. eebooks/3453 and won't be converted into URI.
                // May as well filter these out since they will never work.
                if (Webpage.StartsWith("http"))
                {
                    return new Uri(Webpage);
                }
            }
            catch (Exception)
            {
            }
            return new Uri("http://wikipedia.com");
        }
    }

    public override string ToString()
    {
        return $"{Name} relator {PersonType}={(int)PersonType})";
    }
}
