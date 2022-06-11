import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchcarbyYear'
})
export class SearchcarbyYearPipe implements PipeTransform {
//פייפ לחיפוש לפי שנת ייצור
  transform(Cars: any[], character: number): number[] {
    if (character === undefined) {
      return Cars;
    }
    else {
      return Cars.filter(function (type) {
        return type.year.toString().includes(character.toString());
      })
    }
  }
}
