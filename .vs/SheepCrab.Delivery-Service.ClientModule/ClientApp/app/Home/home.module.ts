import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { LandingPageImagesComponent } from "./LandingPageImage/landing-page-images.component";
import { HttpClientModule } from "@angular/common/http";

import { Carousel } from "../Carousel/carousel.component";
import { Slide } from "../Carousel/slide.component";

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [LandingPageImagesComponent, Carousel, Slide],
    exports: [LandingPageImagesComponent]
})

export class HomeModule {}
