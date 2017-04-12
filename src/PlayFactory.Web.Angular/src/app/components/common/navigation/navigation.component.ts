import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

import { UserProfileService } from '../../../core/services/user-profile.service';

declare var jQuery:any;

@Component({
    selector: 'navigation',
    templateUrl: 'navigation.template.html'
})

export class NavigationComponent implements OnInit {

    userProfileImg: String;

    constructor(private router: Router, private userProfile: UserProfileService) {  }

    ngOnInit(): void {
        this.userProfileImg = this.userProfile.getUrlProfile();
    }

    ngAfterViewInit() {
        jQuery('#side-menu').metisMenu();
    }

    activeRoute(routename: string): boolean{
        return this.router.url.indexOf(routename) > -1;
    }


}