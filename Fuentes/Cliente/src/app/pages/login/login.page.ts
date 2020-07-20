import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { AuthService } from '../../servicios/autenticacion-service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  validations_form: FormGroup;
  errorMessage: string = '';
  loading: boolean = false;

  validation_messages = {
   'email': [
     { type: 'required', message: 'El correo electrónico es requerido.' },
     { type: 'pattern', message: 'Ingrese un correo electrónico válido.' }
   ],
   'password': [
     { type: 'required', message: 'La contraseña es requerida.' },
     { type: 'minlength', message: 'La contraseña debe tener al menos 5 caracteres.' }
   ]
 };

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router
) { }

  ngOnInit() {
    this.validations_form = this.formBuilder.group({
      email: new FormControl('', Validators.compose([
        Validators.required,
        Validators.pattern('^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$')
      ])),
      password: new FormControl('', Validators.compose([
        Validators.minLength(5),
        Validators.required
      ])),
    });
  }

  tryLogin(value){
    this.loading = true;
    this.authService.doLogin(value)
    .then(res => {
      this.router.navigate(["/inicio"]);
    }, err => {
      this.errorMessage = err.message;
      console.log(err)
    }).finally(
      () => {
        this.loading = false;
      }
    );
  }

}
