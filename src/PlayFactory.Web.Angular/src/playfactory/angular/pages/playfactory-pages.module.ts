import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { PageNotFoundComponent } from './page-notfound.component';

export const routedPlayFactoryPagesComponents = [PageNotFoundComponent];

@NgModule({
  imports: [CommonModule, FormsModule],
  exports: [routedPlayFactoryPagesComponents],
  declarations: [routedPlayFactoryPagesComponents],
  providers: [],
})
export class PlayFactoryPagesModule { }

