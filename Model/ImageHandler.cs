﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

using ImageViewer.Common;

namespace ImageViewer.Model
{
    class ImageHandler : NotificationObject
    {
        #region Singleton

        private static ImageHandler instance = null;
        public static ImageHandler GetInstance()
        {
            if (instance == null)
            {
                instance = new ImageHandler();
            }

            return instance;
        }

        public ImageHandler()
        {
            this.DisplayImage(ImageAttribute.sampleImageFilePath, true);
        }

        #endregion

        #region Event

        #endregion

        #region Method

        private void DisplayImage(String imageFilePath, Boolean isSample = false)
        {
            if (isSample)
            {
                this.MainImage = new BitmapImage(new Uri(imageFilePath, UriKind.Relative));
            }
            else
            {
                this.MainImage = new BitmapImage(new Uri(imageFilePath, UriKind.Absolute));
            }

            this.Thumbnail = this.MainImage;
        }

        public void AddImageFilePath()
        {
            this.ImageFilePaths.Clear();

            // 権限がなくパスが参照できない可能性があるので例外処理
            try
            {
                this.ImageFilePaths.Add(new ImageFilePathInfo(this.ImageDirectoryPath, ImageAttribute.directoryIconPath));
            }
            catch
            {
            }
        }

        public void Test()
        {
            if (this.CurrentImageFilePath == null)
            {
                return;
            }

            this.DisplayImage(this.CurrentImageFilePath.FullPath);
        }

        #endregion

        #region Property

        private String imageDirectoryPath = "";
        public String ImageDirectoryPath
        {
            get { return this.imageDirectoryPath; }
            set
            {
                if (base.RaisePropertyChangedIfSet(ref this.imageDirectoryPath, value))
                {
                    base.RaisePropertyChanged();
                }
            }
        }

        private ObservableCollection<ImageFilePathInfo> imageFilePaths = new ObservableCollection<ImageFilePathInfo>();
        public ObservableCollection<ImageFilePathInfo> ImageFilePaths
        {
            get { return this.imageFilePaths; }
            set
            {
                if (base.RaisePropertyChangedIfSet(ref this.imageFilePaths, value))
                {
                    base.RaisePropertyChanged();
                }
            }
        }

        private ImageFilePathInfo currentImageFilePath;
        public ImageFilePathInfo CurrentImageFilePath
        {
            get { return this.currentImageFilePath; }
            set
            {
                if (base.RaisePropertyChangedIfSet(ref this.currentImageFilePath, value))
                {
                    base.RaisePropertyChanged();
                }
            }
        }

        private BitmapImage thumbnail;
        public BitmapImage Thumbnail
        {
            get { return this.thumbnail; }
            set
            {
                if (base.RaisePropertyChangedIfSet(ref this.thumbnail, value))
                {
                    base.RaisePropertyChanged();
                }
            }
        }

        private BitmapImage mainImage;
        public BitmapImage MainImage
        {
            get { return this.mainImage; }
            set
            {
                if (base.RaisePropertyChangedIfSet(ref this.mainImage, value))
                {
                    base.RaisePropertyChanged();
                }
            }
        }

        #endregion
    }
}
