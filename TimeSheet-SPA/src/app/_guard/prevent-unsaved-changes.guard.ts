import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { UserProfileComponent } from '../profile/user-profile/user-profile.component';

@Injectable()
export class PreventUnsavedChangesGuard implements CanDeactivate<UserProfileComponent> {
  canDeactivate(component: UserProfileComponent) {
    if (component.editForm.dirty) {
      return confirm('Jestes pewien, ze chcesz kontynuwac? Wszystkie niezapisane zmiany przepadna.');
    }
    return true;
  }
}
