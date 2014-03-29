using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aga.Controls.Tree;

namespace CCPlistEditor
{
    class PlistNode : Node
    {
        /// <exception cref="ArgumentNullException">Argument is null.</exception>
	    public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException();

				base.Text = value;
			}
		}

		private bool _checked;
        /// <summary>
        /// Whether the box is checked or not.
        /// </summary>
		public bool Checked
		{
			get { return _checked; }
			set { _checked = value; }
		}

        /// <summary>
        /// Initializes a new MyNode class with a given Text property.
        /// </summary>
        /// <param name="text">String to set the text property with.</param>
        public PlistNode(string text)
			: base(text)
		{
		}
    }
}
