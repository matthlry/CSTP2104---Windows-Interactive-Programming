using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using BusinessLogic;
using SharedCommon.Interfaces;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CourseEnroll
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private readonly IStudentRepository studentRepository;
        private readonly ICourseRepository courseRepository;
        public MainWindow()
        {
            this.InitializeComponent();            
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            //myButton.Content = "Clicked";
        }

        private void getStudents_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            //string student = studentFilter.GetValue();
            //BusinessLogic.StudentManager manager = new StudentManager(studentRepository, courseRepository);
            //studentList.ItemsSource = manager.GetRegisteredStudents();
            
        }

        private void courseSearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void studentList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
