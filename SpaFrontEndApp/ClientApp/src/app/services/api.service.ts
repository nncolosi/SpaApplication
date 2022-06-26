import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ApiService {
    constructor(private http: HttpClient) { }

    getCategories(): Observable<any> {
        return this.http.get<string[]>('https://api.chucknorris.io/jokes/categories');
    }

    getRandomJoke(category: string): Observable<any> {
        return this.http.get<any>('https://api.chucknorris.io/jokes/random?category=' + category);
    }

    getPeople(): Observable<any> {
        return this.http.get<any>('https://swapi.dev/api/people/');
    }

    search(value: string): Observable<any> {
        return this.http.get<any>('https://localhost:44338/search?query=' + value);
    }
}