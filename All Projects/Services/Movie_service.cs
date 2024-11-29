using CRUD_Post.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Post.Services;

public class Movie_service
{
    private List<Movie> ListedMovies;

    public Movie_service()
    {
        ListedMovies = new List<Movie>();
    }


    public Movie AddMovie(Movie film)
    {
        film.Id = Guid.NewGuid();
        ListedMovies.Add(film);

        return film;
    }



    public Movie GetById(Guid movieId)
    {
        foreach(var film in ListedMovies)
        {
            if(film.Id == movieId)
            {
                return film;
            }
        }
        return null;
    }


    public List<Movie> GetAllMovies()
    {
        return ListedMovies;
    }



    public bool DeletedMovie(Guid movieId)
    {
        var foundMovie = GetById(movieId);

        if(foundMovie is null)
        {
            return false;
        }
        ListedMovies.Remove(foundMovie);
        return true;
    }



    public bool UpdatedMovie(Guid movieId, Movie film)
    {
        var foundMovie = GetById(movieId);

        if(foundMovie is null)
        {
            return false;
        }

        var index = ListedMovies.IndexOf(foundMovie);
        ListedMovies[index] = film;
        return true;
    }





    public Movie GetExpensiveMovie()
    {
        var movie = new Movie();

        foreach(var film in ListedMovies)
        {
            if(film.AmountOfInvestment > movie.AmountOfInvestment)
            {
                movie = film;
            }
        }
        return movie;
    }





    public Movie GetMostSpentTimeOfMovie()
    {
        var maxMovieTime = new Movie();

        foreach(var film in ListedMovies)
        {
            if(maxMovieTime.MovieTime < film.MovieTime)
            {
                maxMovieTime = film;
            }
        }
        return maxMovieTime;
    }




    public List<Movie> GetMoviesByAuthor(string authorName)
    {
        var films = new List<Movie>();

        foreach(var movie in ListedMovies)
        {
            if(movie.Author == authorName)
            {
                films.Add(movie);
            }
        }
        return films;
    }











}