﻿#pragma checksum "..\..\AdminHome.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CFFC0778A573341A4600DEA54B32ECA36ACFB9BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SWProjv1;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace SWProjv1 {
    
    
    /// <summary>
    /// AdminHome
    /// </summary>
    public partial class AdminHome : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\AdminHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel adminNav;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\AdminHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button msg_btn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\AdminHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button KeyReview_btn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\AdminHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button roomSearch_btn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\AdminHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchStdnt_btn;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\AdminHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RAReview_btn;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\AdminHome.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock test;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SWProjv1;component/adminhome.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminHome.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.adminNav = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            this.msg_btn = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\AdminHome.xaml"
            this.msg_btn.Click += new System.Windows.RoutedEventHandler(this.msg_btn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.KeyReview_btn = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\AdminHome.xaml"
            this.KeyReview_btn.Click += new System.Windows.RoutedEventHandler(this.KeyReview_btn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.roomSearch_btn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\AdminHome.xaml"
            this.roomSearch_btn.Click += new System.Windows.RoutedEventHandler(this.roomSearch_btn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.searchStdnt_btn = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\AdminHome.xaml"
            this.searchStdnt_btn.Click += new System.Windows.RoutedEventHandler(this.searchStdnt_btn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RAReview_btn = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\AdminHome.xaml"
            this.RAReview_btn.Click += new System.Windows.RoutedEventHandler(this.RAReview_btn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.test = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

