import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchcarbyModel'
})
export class SearchcarbyModelPipe implements PipeTransform {
// פייפ לסינון על פי דגם
  transform(Cars: any[], character: any): any[] {
    if (character === undefined) {
      return Cars;
    }
    else {
      return Cars.filter(function (type) {
        return type.model.toLowerCase().includes(character.toLowerCase());
      })
    }
  }
}
