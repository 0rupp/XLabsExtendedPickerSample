using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using PickerSample.Annotations;

namespace PickerSample {
    public class MainViewModel : INotifyPropertyChanged {
        private FoodCategory _selectedCategory;
        private Food _selectedFood;

        public MainViewModel() {
            HealthyFoodCategories = new ObservableCollection<FoodCategory>();
            HealthyFoods = new ObservableCollection<Food>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<FoodCategory> HealthyFoodCategories { get; }

        public ObservableCollection<Food> HealthyFoods { get; }

        public FoodCategory SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                if (value != null) {
                    LoadFoods(_selectedCategory);
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCategory)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HealthyFoods))); // desperate try to force update
            }
        }

        public Food SelectedFood
        {
            get { return _selectedFood; }
            set
            {
                _selectedFood = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedFood)));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadFoods(FoodCategory selectedCategory) {
            HealthyFoods.Clear();
            if (selectedCategory.Id == 1) {
                HealthyFoods.Add(new Food { Id = 1, Name = "Banana" });
                HealthyFoods.Add(new Food { Id = 2, Name = "Apple" });
                HealthyFoods.Add(new Food { Id = 3, Name = "Pear" });
            } else if (selectedCategory.Id == 2) {
                HealthyFoods.Add(new Food { Id = 4, Name = "Tomato" });
                HealthyFoods.Add(new Food { Id = 5, Name = "Carrot" });
                HealthyFoods.Add(new Food { Id = 6, Name = "Kale" });
            } else {
                throw new InvalidOperationException("Unkown category");
            }
        }
    }

    public class FoodCategory {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString() {
            return Id + " " + Name;
        }
    }

    public class Food {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString() {
            return Id + " " + Name;
        }
    }
}