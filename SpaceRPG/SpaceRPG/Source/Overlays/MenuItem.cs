// MenuItem.cs
// James Tyson
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SpaceRPG.Source.Visuals;

namespace SpaceRPG.Source.Overlays
{
    /// <summary>
    /// MenuItem represents a single item in a menu
    /// </summary>
    public class MenuItem
    {
        private string _linkType;
        private string _linkID;
        private Image _image;

        #region Accessors
        public string LinkType
        {
            get { return _linkType; }
            set { _linkType = value; }
        }
        public string LinkID
        {
            get { return _linkID; }
            set { _linkID = value; }
        }
        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }
        #endregion
    }
}
