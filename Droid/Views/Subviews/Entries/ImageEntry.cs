﻿
using System;
using Android.Widget;
using Android.Content;
using Android.Graphics;
using Carto.Core;
using Carto.Ui;
using Carto.Layers;

namespace data.collection.Droid
{
    public class ImageEntry : BaseEntry
	{
        ImageView imageView;

        ImageView photoView;
        Bitmap bitmap;
        public Bitmap Photo
        {
            get { return bitmap; }
            set 
            {
                bitmap = value;
                photoView.SetImageBitmap(bitmap);
            }
        }

        public string ImageName { get; set; }

        public ImageEntry(Context context, string title, int resource) : base(context, title)
		{
            photoView = new ImageView(context);
            photoView.SetScaleType(ImageView.ScaleType.CenterCrop);
            AddView(photoView);

			imageView = new ImageView(context);
            imageView.SetImageResource(resource);
			imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
			AddView(imageView);

            BringChildToFront(label);
		}

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            int w = (int)(Frame.H / 3.2);
			int h = w;
            int x = Frame.W / 2 - w / 2;
            int y = Frame.H / 2 - h / 2;

            imageView.SetFrame(x, y, w, h);

            photoView.SetFrame(0, 0, Frame.W, Frame.H);
        }

        public bool IsSet => map != null;

        MapView map;

        public void SetMap(MapView mapView, MapPos position)
        {
            if (map != null)
            {
				map.Zoom = 18;
				map.FocusPos = position;

                return;
			}

            map = mapView;

            map.Enabled = false;
            AddView(map);
            map.MatchParent();

            var layer = new CartoOnlineVectorTileLayer(CartoBaseMapStyle.CartoBasemapStyleVoyager);
            map.Layers.Add(layer);

			map.Zoom = 18;
			map.FocusPos = position;
        }

    }
}