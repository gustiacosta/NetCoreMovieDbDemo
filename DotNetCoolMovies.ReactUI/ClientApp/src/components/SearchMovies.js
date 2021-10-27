import React, { Component } from 'react';

export class SearchMovies extends Component {
    static displayName = SearchMovies.name;

    constructor(props) {
        super(props);
        this.state = { movies: [], loading: true };
    }

    componentDidMount() {
        this.searchMovies("");
    }

    static renderMoviesTable(movies) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Year</th>
                        <th>Title</th>
                        <th>Genre(s)</th>
                        <th>Actor(s)</th>
                    </tr>
                </thead>
                <tbody>
                    {movies.map(movie =>
                        <tr key={movie.id}>
                            <td>{movie.year}</td>
                            <td><strong> {movie.title} </strong></td>
                            <td>{movie.genreListSimple}</td>
                            <td>{movie.actorListSimple}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    onSubmit = (e) => {
        e.preventDefault();
        var search = this.search;
        this.searchMovies(search.value);
    }

    render() {

        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : SearchMovies.renderMoviesTable(this.state.movies);

        return (
            <div>
                <h1 id="tabelLabel" >Movies</h1>
                <p>This component demonstrates fetching data from our api service</p>

                <div className="row g-3">
                    <div className="col-sm-11">
                        <input type="text" placeholder="search.." className="form-control" ref={(c) => this.search = c} />
                    </div>
                    <div className="col-sm-1">
                        <button className="btn btn-primary" onClick={this.onSubmit} >Search</button>
                    </div>
                </div>

                <br />
                {contents}
            </div>
        );
    }

    async searchMovies(searchText) {
        var url = ''
        const { MOVIES_ALL_URL, MOVIES_SEARCH_URL } = process.env

        if (searchText === null || searchText === "") {
            url = 'https://localhost:5001/movies/all'
        } else {
            url = 'https://localhost:5001/movies/search/' + searchText
        }

        fetch(url)
            .then(res => res.json())
            .then((data) => {
                this.setState({ movies: data.data, loading: false })
            })
            .catch(console.log)
    }
}