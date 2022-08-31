import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { StarComponent } from './star/star.component';
import { ConvertCharacterPipe} from './pipes/convert-character.pipe';
import { HoverBtnDirective } from './directives/hover-btn.directive';
import { FormatEmailPipe } from './pipes/format-email.pipe';

@NgModule({
  declarations: [
    StarComponent,
    ConvertCharacterPipe,
    HoverBtnDirective,
    HoverBtnDirective,
    FormatEmailPipe
  ],
  imports: [
    CommonModule,
    
  ],
  exports: [
    CommonModule,
    FormsModule,
    StarComponent,
    ConvertCharacterPipe,
    HoverBtnDirective,
    FormatEmailPipe
  ],
  providers: [FormatEmailPipe, ConvertCharacterPipe]
})
export class SharedModule { }
