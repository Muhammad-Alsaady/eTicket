using eTicket.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess
{
    public class ApplicationDbInitialzer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();
                if (!context.Cinemas.Any())
                {
                    //Cinema
                    if (!context.Cinemas.Any())
                    {
                        context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                    });
                        context.SaveChanges();
                    }
                    //Actors
                    if (!context.Actors.Any())
                    {
                        context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            Name = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePhotoURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            Name = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePhotoURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePhotoURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePhotoURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePhotoURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                        context.SaveChanges();
                    }
                    //Producers
                    if (!context.Producers.Any())
                    {
                        context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            Name = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePhotoURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            Name = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePhotoURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePhotoURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePhotoURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePhotoURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                        context.SaveChanges();
                    }
                    //Movies
                    if (!context.Movies.Any())
                    {
                        context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Title = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaID = 3,
                            ProducerID = 3,
                            Genre = Genre.Documentary
                        },
                        new Movie()
                        {
                            Title = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaID = 1,
                            ProducerID = 1,
                            Genre = Genre.Action
                        },
                        new Movie()
                        {
                            Title = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaID = 4,
                            ProducerID = 4,
                            Genre = Genre.Horror
                        },
                        new Movie()
                        {
                            Title = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaID = 1,
                            ProducerID = 2,
                            Genre = Genre.Documentary
                        },
                        new Movie()
                        {
                            Title = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaID = 1,
                            ProducerID = 3,
                            Genre = Genre.Cartoon
                        },
                        new Movie()
                        {
                            Title = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaID = 1,
                            ProducerID = 5,
                            Genre = Genre.Drama
                        }
                    });
                        context.SaveChanges();
                    }
                    //Actors & Movies
                    if (!context.MovieActors.Any())
                    {
                        context.MovieActors.AddRange(new List<MovieActor>()
                    {
                        new MovieActor()
                        {
                            ActorID = 1,
                            MovieID = 1
                        },
                        new MovieActor()
                        {
                            ActorID = 3,
                            MovieID = 1
                        },

                         new MovieActor()
                        {
                            ActorID = 1,
                            MovieID = 2
                        },
                         new MovieActor()
                        {
                            ActorID = 4,
                            MovieID = 2
                        },

                        new MovieActor()
                        {
                            ActorID = 1,
                            MovieID = 3
                        },
                        new MovieActor()
                        {
                            ActorID = 2,
                            MovieID = 3
                        },
                        new MovieActor()
                        {
                            ActorID = 5,
                            MovieID = 3
                        },


                        new MovieActor()
                        {
                            ActorID = 2,
                            MovieID = 4
                        },
                        new MovieActor()
                        {
                            ActorID = 3,
                            MovieID = 4
                        },
                        new MovieActor()
                        {
                            ActorID = 4,
                            MovieID = 4
                        },


                        new MovieActor()
                        {
                            ActorID = 2,
                            MovieID = 5
                        },
                        new MovieActor
                        {
                            ActorID = 3,
                            MovieID = 5
                        },
                        new MovieActor()
                        {
                            ActorID = 4,
                            MovieID = 5
                        },
                        new MovieActor()
                        {
                            ActorID = 5,
                            MovieID = 5
                        },


                        new MovieActor()
                        {
                            ActorID = 3,
                            MovieID = 6
                        },
                        new MovieActor()
                        {
                            ActorID = 4,
                            MovieID = 6
                        },
                        new MovieActor()
                        {
                            ActorID = 5,
                            MovieID = 6
                        },
                    });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
