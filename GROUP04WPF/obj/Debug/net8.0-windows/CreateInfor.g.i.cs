﻿#pragma checksum "..\..\..\CreateInfor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "781CC94D8BD8ACD331F7248A6BEF78600540DAED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GROUP04WPF;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GROUP04WPF {
    
    
    /// <summary>
    /// CreateInfor
    /// </summary>
    public partial class CreateInfor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\CreateInfor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRoomNumber;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\CreateInfor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRoomDetailDescription;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\CreateInfor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRoomMaxCapacity;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\CreateInfor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbRoomTypeId;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\CreateInfor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRoomPricePerDay;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\CreateInfor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateButton;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\CreateInfor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GROUP04WPF;component/createinfor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CreateInfor.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtRoomNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtRoomDetailDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtRoomMaxCapacity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cbRoomTypeId = ((System.Windows.Controls.ComboBox)(target));
            
            #line 46 "..\..\..\CreateInfor.xaml"
            this.cbRoomTypeId.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbRoomTypeId_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtRoomPricePerDay = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.CreateButton = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\CreateInfor.xaml"
            this.CreateButton.Click += new System.Windows.RoutedEventHandler(this.CreateButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\CreateInfor.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

