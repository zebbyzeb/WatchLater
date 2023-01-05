using System.Windows.Input;

namespace WatchLater;

public partial class MainPage : ContentPage
{
    private readonly List<Guid> selectedMovies = new List<Guid>();

    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        movieCollectionView.ItemsSource = MockData.Movies;
        ToggleAddOff();
    }

    private void ToggleAddOn()
    {
        grid.Remove(addButtonFrame);
        grid.Remove(movieCollectionView);

        grid.RowDefinitions = new RowDefinitionCollection
        {
            new RowDefinition
            {
                Height = new GridLength(0.2, GridUnitType.Star)
            },
            new RowDefinition
            {
                Height = new GridLength(1, GridUnitType.Star)
            },
        };

        grid.Add(addButtonFrame, 0, 0);
        grid.Add(movieCollectionView, 0, 1);
    }

    private void ToggleAddOff()
    {
        grid.Remove(addButtonFrame);
        grid.Remove(movieCollectionView);

        grid.RowDefinitions = new RowDefinitionCollection
        {
            new RowDefinition
            {
                Height = new GridLength(1, GridUnitType.Star)
            },
        };
        grid.Add(movieCollectionView, 0, 0);
    }

    private void ToggleAddButtonVisibility()
    {
        if (selectedMovies.Any())
        {
            ToggleAddOn();
        }
        else
        {
            ToggleAddOff();
        }
    }

    private void AddMovie(Movie movie, object sender)
    {
        var selectedFrame = (Frame)sender;
        selectedMovies.Add(movie.MovieUUID);
        selectedFrame.Background = Colors.Black;
    }

    private void RemoveMovie(Movie movie, object sender)
    {
        var selectedFrame = (Frame)sender;
        selectedMovies.Remove(movie.MovieUUID);
        selectedFrame.Background = Colors.Red;
    }

    public void OnTap(object sender, EventArgs args)
    {
        var tappedEventArgs = (TappedEventArgs)args;
        var movieParam = (Movie)tappedEventArgs.Parameter;

        if (selectedMovies.Any(sm => sm == movieParam.MovieUUID))
        {
            RemoveMovie(movieParam, sender);
        }
        else
        {
            AddMovie(movieParam, sender);
        }

        ToggleAddButtonVisibility();
    }


}

