using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Daily_Planner
{
    
    public partial class MainWindow : Window
    {
        
        public List<TextBox> textBoxes = new List<TextBox>();
        public int selectedIndex;
        public MainWindow()
        {
            InitializeComponent();
            if (Note.Notes != null)
            {
                ShowNotesName();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Serialize_Deserealize.CheckData();
            AddLists();

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /*Serialize_Deserealize.SaveData(Note.Notes, Serialize_Deserealize.file);*/
        }
        private void AddLists()
        {
            textBoxes.Add(tbName);
            textBoxes.Add(tbDescription);
        }

        private void ShowNotesName()
        {

            
            List<string> notesName= new List<string>();
            if (Note.todaynote == null)
            {
                for (int i = 0; i < Note.Notes.Count; i++)
                {
                    notesName.Add(Note.Notes[i].Name);
                }
                lb.ItemsSource = notesName;
            }
            else
            {
                foreach (var item in Note.todaynote)
                {
                    notesName.Add(item.Name);
                }
                lb.ItemsSource = notesName;
            }
        }
        private void TbName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbName.Text == "Add Note's Name")
            {
                tbName.Clear();
            }
        }

        private void TbDescription_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbDescription.Text == "Add Note's Description")
            {
                tbDescription.Clear();
            }
        }

        private void butSave_Click(object sender, RoutedEventArgs e)
        {
            Note.Notes[selectedIndex].Name = tbName.Text;
            Note.Notes[selectedIndex].Description = tbDescription.Text;
            Note.Notes[selectedIndex].Date = Convert.ToDateTime(datePicker.Text);
        }

        private void butCreate_Click(object sender, RoutedEventArgs e)
        {
                Note.Notes = new List<Note>() 
                {   
                    new Note()
                    {
                        Name = tbName.Text,
                        Description = tbDescription.Text,
                        Date = Convert.ToDateTime(datePicker.Text)
                    }
                };
/*
           Note item =  new Note()
            {
                Name = tbName.Text,
                Description = tbDescription.Text,
                Date = Convert.ToDateTime(datePicker.Text)
            };
            Note.Notes.Add(item);*/
                ShowNotesName();
        }

        private void lb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            butSave.IsEnabled = true;
            butDel.IsEnabled = true;
            selectedIndex = Convert.ToInt32(lb.Items[lb.SelectedIndex]);
            tbName.Text = Note.Notes[selectedIndex].Name;
            tbDescription.Text = Note.Notes[selectedIndex].Description;
        }

        private void butDel_Click(object sender, RoutedEventArgs e)
        {
            Note.Notes.RemoveAt(selectedIndex);
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Note.todaynote = Note.Notes.Where(item => item.Date == Convert.ToDateTime(datePicker.Text)).ToList();
            }
            catch (ArgumentNullException)
            {

            }
        }
    }
}
