import httpClient from '../common/HttpClient'

import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';

export const Setup = vue => {
    httpClient.init();
    httpClient.setLocalization();

    vue.use(VueSweetalert2)
    vue.use(require('vue-moment'))
}