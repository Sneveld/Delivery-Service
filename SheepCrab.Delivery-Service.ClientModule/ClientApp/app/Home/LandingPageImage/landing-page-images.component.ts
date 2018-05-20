import { Component, OnInit } from '@angular/core';
import { LandingPageImage } from "./landing-page-image.dto";
import { LandingPageImageService } from "./landing-page-image.service";

@Component({
    selector: 'landing-page',
    template: `<carousel [noWrap]="true">
                          <slide *ngFor="let slidez of slides; let index=index" [active]="slidez.active">
                               <img [src]="'data:image/JPEG;base64,' + slidez.image" style= "margin:auto" />
                            <div class="carousel-caption">
                              <h3 style="background-color: transparent;color: white;">Slide {{index + 1}}</h3>
                              <p  style="background-color: transparent;color: white;">{{slidez.text}}</p>
                            </div>
                          </slide>
                        </carousel>`,
    providers: [LandingPageImageService]
})

export class LandingPageImagesComponent implements OnInit {
    slides: LandingPageImage[]

    constructor(private landingPageImageService: LandingPageImageService) {

    }

    ngOnInit() {
        this.loadSliders();
    }

    loadSliders() {
        this.landingPageImageService.getAllLandingImages()
            .subscribe((data: LandingPageImage[]) =>
            {
                this.slides = data
            });
    }
}