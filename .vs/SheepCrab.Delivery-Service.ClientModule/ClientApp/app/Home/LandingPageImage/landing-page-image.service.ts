import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class LandingPageImageService {

    private url = "/Home/GetLandingPageImages";

    constructor(private http: HttpClient) {

    }

    getAllLandingImages() {
        return this.http.get(this.url);
    }
}