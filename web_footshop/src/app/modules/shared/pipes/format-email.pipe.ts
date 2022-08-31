import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formatEmail'
})
export class FormatEmailPipe implements PipeTransform {

  transform(value: string): string {
    return value.slice(0, value.indexOf('@'));
  }

}
