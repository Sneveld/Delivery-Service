import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ProductMenuService {

    private url = "/MainMenu/";

    constructor(private http: HttpClient) {

    }

    getSiteMenu() {
        return this.http.get(this.url + "GetSiteMenu");
    }

    updateProducts(id: string) {
        return this.http.get(this.url + "UpDateProducts", { params: { param: id }});
    }

    find(name: string) {
        return this.http.get(this.url + "Find", { params: { findname: name } });
    }

    getAllProducts() {
        return this.http.get(this.url + "GetAllProducts");
    }

}