import { Component, OnInit } from '@angular/core';
import { ApiService } from '../services/api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
    categoryList: string[] = [];
    joke: string;
    people: any;
    searchStr: string;
    jokeList: any;
    constructor(private apiService: ApiService) { }
    ngOnInit(): void {
        this.getCategories();
        this.getPeople();
    }

    getCategories() {
        this.apiService.getCategories().subscribe(data => {
            this.categoryList = <string[]>data;
        });
    }

    onSelectCat(cat: string) {
        this.apiService.getRandomJoke(cat).subscribe(data => {
            this.joke = data.value;
        });
    } 

    getPeople() {
        this.apiService.getPeople().subscribe(data => {
            this.people = data.results;
            console.log(data);
        });
    }

    onSearch() {
        this.apiService.search(this.searchStr).subscribe(data => {
            this.jokeList = data.jokes.result;
            this.people = data.people.results;
        });
    }
}
