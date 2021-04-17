using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace PopupDlgAnimations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double left, top, right, bottom, centerX, centerY;
        private DoubleAnimation bottomToCenterAnimiation, topToCenterAnimation,
            leftToCenterAnimation, rightToCenterAnimation;
        private Storyboard bottomToCenterStoryboard, topToCenterStoryboard,
            leftToCenterStoryboard, rightToCenterStoryboard;

        

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
            this.SizeChanged += MainWindow_SizeChanged;
        }


        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            try
            {
                SetPopupDlgCenter();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                SetPopupDlgCenter();

                InitializeAnimations();
            }
            catch (Exception)
            {

                throw;
            }
        }


        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if (popupGrid.Visibility == Visibility.Visible)
                {
                    popupGrid.Visibility = Visibility.Hidden;
                }
            }
        }


        private void showPopupButton_Click(object sender, RoutedEventArgs e)
        {
            popupGrid.Visibility = Visibility.Visible;
        }

        private void bottomToCenterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetPopupDlgCenter();
                bottomToCenterAnimiation.From = bottom;
                bottomToCenterAnimiation.To = centerY;

                Canvas.SetTop(popupBd, bottom);

                popupGrid.Visibility = Visibility.Visible;

                bottomToCenterStoryboard.Begin();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void topToCenterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetPopupDlgCenter();
                topToCenterAnimation.From = top;
                topToCenterAnimation.To = centerY;

                Canvas.SetTop(popupBd, top);

                popupGrid.Visibility = Visibility.Visible;

                topToCenterStoryboard.Begin();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void leftToCenterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetPopupDlgCenter();
                leftToCenterAnimation.From = left;
                leftToCenterAnimation.To = centerX;

                Canvas.SetLeft(popupBd, Left);

                popupGrid.Visibility = Visibility.Visible;

                leftToCenterStoryboard.Begin();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void rightToCenterButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetPopupDlgCenter();
                rightToCenterAnimation.From = right;
                rightToCenterAnimation.To = centerX;

                Canvas.SetLeft(popupBd, Left);

                popupGrid.Visibility = Visibility.Visible;

                rightToCenterStoryboard.Begin();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            popupGrid.Visibility = Visibility.Hidden;

        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            popupGrid.Visibility = Visibility.Hidden;

        }
        

        private void SetPopupDlgCenter()
        {
            try
            {
                left = -(popupBd.ActualWidth);
                top = -(popupBd.ActualHeight);
                right = (popupGrid.ActualWidth);
                bottom = (popupGrid.ActualHeight);

                centerX = (popupGrid.ActualWidth / 2) - popupBd.ActualWidth / 2;
                centerY = (popupGrid.ActualHeight / 2) - popupBd.ActualHeight / 2;

                Canvas.SetLeft(popupBd, centerX);
                Canvas.SetTop(popupBd, centerY);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void InitializeAnimations()
        {
            try
            {
                #region bottom to center animation
                bottomToCenterAnimiation = new DoubleAnimation()
                {
                    From = bottom,
                    To = centerY,
                    Duration = TimeSpan.FromMilliseconds(250),
                    FillBehavior = FillBehavior.Stop,
                };

                Storyboard.SetTarget(bottomToCenterAnimiation, popupBd);
                Storyboard.SetTargetProperty(bottomToCenterAnimiation, new PropertyPath(Canvas.TopProperty));

                bottomToCenterStoryboard = new Storyboard();
                bottomToCenterStoryboard.Children.Add(bottomToCenterAnimiation);

                bottomToCenterStoryboard.Completed += OnStoryboardCompleted;
                #endregion

                #region top to center animation 
                topToCenterAnimation = new DoubleAnimation()
                {
                    From = top,
                    To = centerY,
                    Duration = TimeSpan.FromMilliseconds(250),
                    FillBehavior = FillBehavior.Stop,
                };

                Storyboard.SetTarget(topToCenterAnimation, popupBd);
                Storyboard.SetTargetProperty(topToCenterAnimation, new PropertyPath(Canvas.TopProperty));

                topToCenterStoryboard = new Storyboard();
                topToCenterStoryboard.Children.Add(topToCenterAnimation);

                topToCenterStoryboard.Completed += OnStoryboardCompleted;
                #endregion

                #region left to center animation
                leftToCenterAnimation = new DoubleAnimation()
                {
                    From = left,
                    To = centerX,
                    Duration = TimeSpan.FromMilliseconds(250),
                    FillBehavior = FillBehavior.Stop,
                };

                Storyboard.SetTarget(leftToCenterAnimation, popupBd);
                Storyboard.SetTargetProperty(leftToCenterAnimation, new PropertyPath(Canvas.LeftProperty));

                leftToCenterStoryboard = new Storyboard();
                leftToCenterStoryboard.Children.Add(leftToCenterAnimation);

                leftToCenterStoryboard.Completed += OnStoryboardCompleted;
                #endregion

                #region right to center animation
                rightToCenterAnimation = new DoubleAnimation()
                {
                    From = right,
                    To = centerX,
                    Duration = TimeSpan.FromMilliseconds(250),
                    FillBehavior = FillBehavior.Stop,
                };

                Storyboard.SetTarget(rightToCenterAnimation, popupBd);
                Storyboard.SetTargetProperty(rightToCenterAnimation, new PropertyPath(Canvas.LeftProperty));

                rightToCenterStoryboard = new Storyboard();
                rightToCenterStoryboard.Children.Add(rightToCenterAnimation);

                rightToCenterStoryboard.Completed += OnStoryboardCompleted;

                #endregion
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void OnStoryboardCompleted(object sender, EventArgs e)
        {
            Canvas.SetLeft(popupBd, centerX);
            Canvas.SetTop(popupBd, centerY);
        }
    }
}
