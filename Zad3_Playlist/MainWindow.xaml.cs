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

namespace Zad3_Playlist
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Playlist playlist;
        public MainWindow()
        {
            InitializeComponent();
            playlist = new Playlist();
            Update();
        }

        //добавить трек
        private void AddTrack_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAuthor.Text) &&
                !string.IsNullOrWhiteSpace(txtTitle.Text) &&
                !string.IsNullOrWhiteSpace(txtFilename.Text))
            {
                playlist.AddTrack(txtAuthor.Text, txtTitle.Text, txtFilename.Text);
                txtAuthor.Clear();
                txtTitle.Clear();
                txtFilename.Clear();
                Update();
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        //переход к началу
        private void Nach_Click(object sender, RoutedEventArgs e)
        {
            if (!playlist.Nach())
            {
                MessageBox.Show("Плейлист пуст");
            }
            Update();
        }

        //удаление трека
        private void DelTrack_Click(object sender, RoutedEventArgs e)
        {
            if (listTracks.SelectedItem != null)
            {
                int Index = listTracks.SelectedIndex;
                playlist.DelTrack(Index);
                Update();
            }
        }

        //отчистить плейлист
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            playlist.Clear();
            Update();
        }

        //следующий трек
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            playlist.NextTrack();
            Update();
        }

        //предыдущий трек
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            playlist.BackTrack();
            Update();
        }

        //выбор песни в листе
        private void LstTracks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listTracks.SelectedItem != null)
            {
                int index = listTracks.SelectedIndex;
                playlist.IndexTrack(index);

                try
                {
                    Track current = playlist.CurrentSong();
                    txtCurrentSong.Text = $"Сейчас играет: {current.Author} - {current.Title}";
                }
                catch
                {
                    txtCurrentSong.Text = "Нет композиций в плейлисте";
                }
            }
        }

        //обновление
        private void Update()
        {
            listTracks.ItemsSource = null;
            listTracks.ItemsSource = playlist.AllTrack();

            try
            {
                Track current = playlist.CurrentSong();
                txtCurrentSong.Text = $"Сейчас играет: {current.Author} - {current.Title}";
            }
            catch
            {
                txtCurrentSong.Text = "Нет композиций в плейлисте";
            }
        }
    }
}
