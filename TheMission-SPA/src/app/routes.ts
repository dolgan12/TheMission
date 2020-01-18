import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserskillListComponent } from './userskill-list/userskill-list.component';
import { ListComponent } from './list/list.component';
import { AuthGuard } from './_guards/auth.guard';

export const appRoutes: Routes = [
    {path: 'home', component: HomeComponent},
    {path: 'userskill', component: UserskillListComponent, canActivate: [AuthGuard]},
    {path: 'list', component: ListComponent, canActivate: [AuthGuard]},
    {path: '**', redirectTo: 'home', pathMatch: 'full'}
]