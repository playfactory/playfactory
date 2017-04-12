import { Injectable } from '@angular/core';
import { Gender } from '../types'


@Injectable()
export class UserProfileService {
  
    getUrlProfile() : String {
        let img;
        let folderAvatar = "../../src/playfactory/img/avatar/";

        if (this.getUserGender() == Gender.Male)
            img = "user-profile-male-mini.png";
        else
            img = "user-profile-female-mini.png";

        return folderAvatar + img;
    }

    getUserGender() : Gender {
        return Gender.Male;
    }

}
