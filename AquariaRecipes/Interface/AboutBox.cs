using Enhancer.Assemblies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JAL.AquariaRecipes.Interface
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            Text = String.Format("About {0}", AssemblyTitle);
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = String.Format("Version {0:3}", VersionInfo.ProductVersion);
            labelCopyright.Text = AssemblyCopyright;
            labelCompanyName.Text = AssemblyCompany;
            textBoxDescription.Text = AssemblyDescription;
        }

        #region Assembly Attribute Accessors

        private Assembly ExecutingAssembly => Assembly.GetExecutingAssembly();

        public string AssemblyTitle
        {
            get
            {
                return ExecutingAssembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title ?? Path.GetFileNameWithoutExtension(ExecutingAssembly.CodeBase);
            }
        }

        public string AssemblyDescription
        {
            get
            {
                return ExecutingAssembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description ?? "";
            }
        }

        public string AssemblyProduct
        {
            get
            {
                return ExecutingAssembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product ?? "";
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                return ExecutingAssembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? "";
            }
        }

        public string AssemblyCompany
        {
            get
            {
                return ExecutingAssembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company ?? "";
            }
        }
        #endregion
    }
}
