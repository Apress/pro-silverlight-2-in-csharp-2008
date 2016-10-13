using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace ExpanderControl
{    
    [TemplatePart(Name = "Content", Type = typeof(FrameworkElement))]    
    [TemplatePart(Name = "ExpandCollapseButton", Type = typeof(ToggleButton))]
    [TemplateVisualState(Name = "Expanded", GroupName = "ViewStates")]  
    [TemplateVisualState(Name = "Collapsed", GroupName="ViewStates")]    
    public class Expander : ContentControl 
    {
        public Expander()
        {
            DefaultStyleKey = typeof(Expander);
        }


        private void ChangeVisualState(bool useTransitions)
        {
            //  Apply the current state from the ViewStates group.
            if (IsExpanded)
            {
                if (contentElement != null) contentElement.Visibility = Visibility.Visible;
            
               VisualStateManager.GoToState(this, "Expanded", useTransitions);
            }
            else
            {
                VisualStateManager.GoToState(this, "Collapsed", useTransitions);
                if (collapsedState == null)
                {
                    // There is no state animation, so just hide the content region immediately.
                    if (contentElement != null) contentElement.Visibility = Visibility.Collapsed;
                }
            }

            // (If there were other state groups, you would set them now.)           
        }

        public static readonly DependencyProperty CornerRadiusProperty =
           DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Expander), null);
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty HeaderContentProperty =
           DependencyProperty.Register("HeaderContent", typeof(object), typeof(Expander), null);
        public object HeaderContent
        {
            get { return (object)GetValue(HeaderContentProperty); }
            set { SetValue(HeaderContentProperty, value); }
        }

        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register("IsExpanded", typeof(bool), typeof(Expander), new PropertyMetadata(true));
                
        private ToggleButton cmdExpandOrCollapse;        
        private FrameworkElement contentElement;
        private VisualState collapsedState;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
                        
            contentElement = GetTemplateChild("Content") as FrameworkElement;
            if (contentElement != null)
            {
                collapsedState = GetTemplateChild("Collapsed") as VisualState;
                if ((collapsedState != null) && (collapsedState.Storyboard != null))
                {                    
                    collapsedState.Storyboard.Completed += collapsedStoryboard_Completed;
                }
            }

            cmdExpandOrCollapse = GetTemplateChild("ExpandCollapseButton") as ToggleButton;
            if (cmdExpandOrCollapse != null)
            {
                cmdExpandOrCollapse.Click += cmdExpandCollapseButton_Click;                   
            }
            ChangeVisualState(false);
        }

        private void collapsedStoryboard_Completed(object sender, EventArgs e)
        {
            contentElement.Visibility = Visibility.Collapsed;
        }              
               
        public bool IsExpanded
        {
            get { return (bool)GetValue(IsExpandedProperty); }
            set {                
                SetValue(IsExpandedProperty, value);
                if (cmdExpandOrCollapse != null) cmdExpandOrCollapse.IsChecked = IsExpanded;                
            }   
        }


        private void cmdExpandCollapseButton_Click(object sender, RoutedEventArgs e)
        {
            ExpandOrCollapse(true);
        }

        public void ExpandOrCollapse(bool useTransitions)
        {
            IsExpanded = !IsExpanded;

            ChangeVisualState(useTransitions);      
        }

    }
}
