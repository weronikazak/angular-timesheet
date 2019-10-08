import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterNamePipePipe implements PipeTransform {

  transform(items: any[], selected: string): any[] {
    if (!items) {
      return [];
    }
    if (!selected) {
      return items;
    }

    selected = selected.toLowerCase();

    return items.filter(it => {
      return it.toLowerCase().includes(selected);
    });
  }

}
