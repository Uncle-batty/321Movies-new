import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/user.service';
// ...



@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent {
constructor(private router: Router, private userService: UserService) {}
email: string = ''; // Initialize with an empty string
password: string = '';

submitForm() {

  this.userService.loginuser(this.email).subscribe(
      (response) => {
        console.log('Response from loginuser:', response);

        if (response && response.password === this.password) {
          this.router.navigate(['/user-home']);

        } else {
         console.log('Password does not match');
          // Handle incorrect password
        }
      },
      (error) => {
        console.error('Error:', error);

      }
    );
}
}
