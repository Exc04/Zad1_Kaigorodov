using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad3_Playlist
{
    class Playlist
    {
        private List<Track> list;
        private int currentIndex;
        public List<Track> AllTrack() => new List<Track>(list);
        public Playlist()
        {
            list = new List<Track>();
            currentIndex = 0;
        }

        public int Count => list.Count;
        public int CurIndx => currentIndex;
        public Track CurrentSong()
        {
            if (list.Count > 0)
                return list[currentIndex];
            else
                throw new IndexOutOfRangeException("Невозможно получить текущую аудиозапись для пустого плейлиста!");
        }

        //перегрузка добавлления аудио 2
        public void AddTrack(Track track)
        {
            list.Add(track);
        }
        
        //перегрузка добавлления аудио 2
        public void AddTrack(string author, string title, string filename)
        {
            Track newTrack = new Track
            {
                Author = author,
                Title = title,
                Filename = filename
            };
            list.Add(newTrack);
        }

        //переход к следующей
        public void NextTrack()
        {
            if (list.Count == 0)
            {
                return;
            }
            if (currentIndex + 1 < list.Count)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
        }

        //переход к предыдущей
        public void BackTrack()
        {
            if (list.Count == 0)
            {
                return;
            }
            if (currentIndex - 1 >= 0 )
            {
                currentIndex--;
            }
            else
            {
                currentIndex = list.Count - 1;
            }
        }

        //переход по индексу записи
        public bool IndexTrack(int Index)
        {
            if (list.Count == 0)
            {
                return false;
            }
            if (Index < 0 || Index >= list.Count)
            {
                return false;
            }
            currentIndex = Index;
            return true;
        }

        //переход к началу списка
        public bool Nach()
        {
            if (list.Count == 0)
            {
                return false;
            }
            currentIndex = 0;
            return true;
        }

        //удаление композиции 1
        public bool DelTrack(int Index)
        {
            if (Index < 0 || Index >= list.Count)
            {
                return false;
            }
            list.RemoveAt(Index);
            return true;
        }

        //удаление композиции 2
        public bool DelTrack(Track track)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Author == track.Author &&
                    list[i].Title == track.Title &&
                    list[i].Filename == track.Filename)
                {
                    return DelTrack(i);
                }
            }
            return false;
        }

        //очистка плейлиста
        public void Clear()
        {
            list.Clear();
            currentIndex = 0;
        }

       
    }
}
