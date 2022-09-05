import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShowReelInfoComponent } from './components/show-reel-info/show-reel-info.component';
import { ShowReelListComponent } from './components/show-reel-list/show-reel-list.component';
import { ShowReelEditorComponent } from './components/show-reel-editor/show-reel-editor.component';

@NgModule({
  declarations: [
    AppComponent,
    ShowReelListComponent,
    ShowReelInfoComponent,
    ShowReelEditorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
