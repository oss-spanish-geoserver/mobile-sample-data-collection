﻿
using System;
using CoreGraphics;
using UIKit;

namespace data.collection.iOS
{
    public class TextEntry : BaseEntry
    {
        public UITextView Field { get; private set; }

        public string Text 
        { 
            get { return Field.Text; }
            set { Field.Text = value; }
        }

        public TextEntry(string title) : base(title)
        {
            Field = new UITextView();
            Field.TextColor = UIColor.DarkGray;
            Field.Font = UIFont.FromName("HelveticaNeue", 14);
            AddSubview(Field);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

			nfloat x = padding;
            nfloat y = label.Frame.Height + 2 * padding;
			nfloat w = Frame.Width - 2 * padding;
            nfloat h = Frame.Height - (label.Frame.Height + 3 * padding);

            Field.Frame = new CGRect(x, y, w, h);
        }
    }
}