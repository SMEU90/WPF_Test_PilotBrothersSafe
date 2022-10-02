using WPF_Test_PilotBrothersSafe.Services.Interfaces;
using WPF_Test_PilotBrothersSafe.ViewModels.Base;
using WPF_Test_PilotBrothersSafe.Models;
using System.Collections.ObjectModel;
using System.Windows;
using WPF_Test_PilotBrothersSafe.Infrastructure.Commands.Base;
using WPF_Test_PilotBrothersSafe.Infrastructure.Commands;

namespace WPF_Test_PilotBrothersSafe.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Приватные поля
        private readonly IUserDialog _UserDialog;
        private readonly IDataService _DataService;
        #endregion

        #region Title : string - Заголовок окна

        /// <summary>Заголовок окна</summary>
        private string _Title = "Тестовое задание Дегтерев С.О.";

        /// <summary>Заголовок окна</summary>
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        public MainWindowViewModel(IUserDialog UserDialog, IDataService DataService)
        {
            _UserDialog = UserDialog;
            _DataService = DataService;
            ResizeMatrix = new LambdaCommand(OnResizeMatrixExecuted, CanResizeMatrixExecute);
            SizeMatrix = 5;
            #region Изначальное поле
            AllLeverItemsSource.Clear();
            var obsColl = new ObservableCollection<Lever>();
            Lever lever = new Lever(0, 0, false);
            obsColl.Add(lever);
            lever = new Lever(0, 1, false);
            obsColl.Add(lever);
            lever = new Lever(0, 2, true);
            obsColl.Add(lever);
            AllLeverItemsSource.Add(obsColl);
            obsColl = new ObservableCollection<Lever>();
            lever = new Lever(1, 0, false);
            obsColl.Add(lever);
            lever = new Lever(1, 1, true);
            obsColl.Add(lever);
            lever = new Lever(1, 2, false);
            obsColl.Add(lever);
            AllLeverItemsSource.Add(obsColl);
            obsColl = new ObservableCollection<Lever>();
            lever = new Lever(2, 0, true);
            obsColl.Add(lever);
            lever = new Lever(2, 1, false);
            obsColl.Add(lever);
            lever = new Lever(2, 2, false);
            obsColl.Add(lever);
            AllLeverItemsSource.Add(obsColl);
            #endregion

        }
        #region Свойства
        public int SizeMatrix { get; set; }
        private Lever _selectedItem;
        public Lever SelectedItem
        {
            get => _selectedItem;

            set
            {
                _selectedItem = value;
                TurningHandle();
            }
        }
        #endregion

        //ObservableCollection со всеми элементами
        public ObservableCollection<ObservableCollection<Lever>> AllLeverItemsSource { get; } = new ObservableCollection<ObservableCollection<Lever>>();
        #region Команда для создания новой матрицы NxN
        public Command ResizeMatrix { get; }
        private bool CanResizeMatrixExecute(object p) => true;
        private void OnResizeMatrixExecuted(object p)
        {
            if (SizeMatrix > 1)
            {
                AllLeverItemsSource.Clear();
                for (int i = 0; i < SizeMatrix; i++)
                {
                    var obsColl = new ObservableCollection<Lever>();
                    for (int j = 0; j < SizeMatrix; j++)
                    {
                        Lever lever = new Lever(i, j);
                        obsColl.Add(lever);
                    }
                    AllLeverItemsSource.Add(obsColl);
                }
                VerificationMatrix();
            }
            else
                MessageBox.Show("Некорректные данные");

        }
        #endregion
        //Проверка на открытие сейфа
        public void VerificationMatrix()
        {
            bool flag = true;
            foreach (var item in AllLeverItemsSource)
                foreach (var el in item)
                {
                    if (el.orientation == Lever.Orientation.horizontal)
                        flag = false;
                }
            if (flag)
            {
                MessageBox.Show("Поздравляю, сейф открылся!");
                return;
            }
            flag = true;

            foreach (var item in AllLeverItemsSource)
                foreach (var el in item)
                {
                    if (el.orientation == Lever.Orientation.vertical)
                        flag = false;
                }
            if (flag)
            {
                MessageBox.Show("Поздравляю, сейф открылся!");
                return;
            }
        }
        //Поворот ручек сейфа
        private void TurningHandle()
        {
            foreach (var item in AllLeverItemsSource)
                foreach (var el in item)
                {
                    if (el.X == SelectedItem.X || el.Y == SelectedItem.Y)
                    {
                        if (el.orientation == Lever.Orientation.horizontal)
                        {
                            el.orientation = Lever.Orientation.vertical;
                            el.im_lever = " |";
                        }
                        else
                        {
                            el.orientation = Lever.Orientation.horizontal;
                            el.im_lever = "--";
                        }
                    }
                }


            var obsColl = new ObservableCollection<Lever>();
            Lever lever = new Lever(6, 6);
            obsColl.Add(lever);
            AllLeverItemsSource.Add(obsColl);
            AllLeverItemsSource.Remove(obsColl);
            VerificationMatrix();

        }
    }
}
