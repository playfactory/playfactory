import { NgModule, Optional, SkipSelf } from '@angular/core';
import { throwIfAlreadyLoaded } from '../../playfactory/angular/useful/module-import-guard';
import { UserProfileService } from './services/user-profile.service';


@NgModule({
    imports: [ ],
    exports: [ ], 
    declarations: [ ],
    providers: [ UserProfileService ]
})
export class CoreModule{
    constructor( @Optional() @SkipSelf() parentModule: CoreModule) {
        throwIfAlreadyLoaded(parentModule, 'CoreModule');
    }
}