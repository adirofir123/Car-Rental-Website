import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchcarbymanufacturer'
})
export class SearchcarPipe implements PipeTransform {
// פייפ לסינון על פי יצרן
  transform(Cars: any[], character: any): any[] {
    if (character === undefined) {
      return Cars;
    }
    else {
      return Cars.filter(function (type) {
        return type.manufactor.toLowerCase().includes(character.toLowerCase());
      })
    }
  }

}
