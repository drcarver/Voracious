﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Voracious.Database;

#nullable disable

namespace Voracious.Database.Migrations
{
    [DbContext(typeof(VoraciousDataContext))]
    partial class VoraciousDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Voracious.Core.ViewModel.BookNavigationViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CurrSpot")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrStatus")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("FirstNavigationDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDone")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("MostRecentNavigationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("NCatalogViews")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NReading")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NSpecificSelection")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NSwipeLeft")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NSwipeRight")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("TimeMarkedDone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BookNavigations");
                });

            modelBuilder.Entity("Voracious.Core.ViewModel.BookNoteViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BookNotes");
                });

            modelBuilder.Entity("Voracious.Core.ViewModel.BookViewModel", b =>
                {
                    b.Property<string>("BookId")
                        .HasColumnType("TEXT");

                    b.Property<string>("BookSeries")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookSource")
                        .HasColumnType("TEXT");

                    b.Property<int>("BookType")
                        .HasColumnType("INTEGER");

                    b.Property<long>("DenormDownloadDate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DenormPrimaryAuthor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("DownloadDataId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Imprint")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Issued")
                        .HasColumnType("TEXT");

                    b.Property<string>("LCC")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LCCN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LCSH")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NavigationDataId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NotesId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PGEditionInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PGNotes")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PGProducedBy")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ReviewId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("TitleAlternative")
                        .HasColumnType("TEXT");

                    b.HasKey("BookId");

                    b.HasIndex("DownloadDataId");

                    b.HasIndex("NavigationDataId");

                    b.HasIndex("NotesId");

                    b.HasIndex("ReviewId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Voracious.Core.ViewModel.DownloadDataViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrFileStatus")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("DownloadDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DownloadData");
                });

            modelBuilder.Entity("Voracious.Core.ViewModel.FilenameAndFormatDataViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookViewModelBookId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Extent")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModified")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookViewModelBookId");

                    b.ToTable("FilenameAndFormatDataViewModel");
                });

            modelBuilder.Entity("Voracious.Core.ViewModel.PersonViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aliases")
                        .HasColumnType("TEXT");

                    b.Property<int>("BirthDate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookViewModelBookId")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeathDate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FileAs")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Webpage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookViewModelBookId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Voracious.Core.ViewModel.UserNoteViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BackgroundColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("BookId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("BookNoteViewModelId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ForegroundColor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("MostRecentModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("SelectedText")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookNoteViewModelId");

                    b.ToTable("UserNotes");
                });

            modelBuilder.Entity("Voracious.Core.ViewModel.UserReviewViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BookId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("MostRecentModificationDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("NStars")
                        .HasColumnType("REAL");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserReviews");
                });

            modelBuilder.Entity("Voracious.Core.ViewModel.BookViewModel", b =>
                {
                    b.HasOne("Voracious.Core.ViewModel.DownloadDataViewModel", "DownloadData")
                        .WithMany()
                        .HasForeignKey("DownloadDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Voracious.Core.ViewModel.BookNavigationViewModel", "NavigationData")
                        .WithMany()
                        .HasForeignKey("NavigationDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Voracious.Core.ViewModel.BookNoteViewModel", "Notes")
                        .WithMany()
                        .HasForeignKey("NotesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Voracious.Core.ViewModel.UserReviewViewModel", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DownloadData");

                    b.Navigation("NavigationData");

                    b.Navigation("Notes");

                    b.Navigation("Review");
                });

            modelBuilder.Entity("Voracious.Core.ViewModel.FilenameAndFormatDataViewModel", b =>
                {
                    b.HasOne("Voracious.Core.ViewModel.BookViewModel", null)
                        .WithMany("Files")
                        .HasForeignKey("BookViewModelBookId");
                });

            modelBuilder.Entity("Voracious.Core.ViewModel.PersonViewModel", b =>
                {
                    b.HasOne("Voracious.Core.ViewModel.BookViewModel", null)
                        .WithMany("People")
                        .HasForeignKey("BookViewModelBookId");
                });

            modelBuilder.Entity("Voracious.Core.ViewModel.UserNoteViewModel", b =>
                {
                    b.HasOne("Voracious.Core.ViewModel.BookNoteViewModel", null)
                        .WithMany("Notes")
                        .HasForeignKey("BookNoteViewModelId");
                });

            modelBuilder.Entity("Voracious.Core.ViewModel.BookNoteViewModel", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("Voracious.Core.ViewModel.BookViewModel", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}
