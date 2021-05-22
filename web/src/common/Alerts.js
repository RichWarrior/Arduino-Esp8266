import Vue from 'vue'
export const ShowSuccessMessage = (message) => {
    if (!message) {
        Vue.swal({
            position: 'top-end',
            icon: 'success',
            title: 'Your transaction has been completed successfully',
            showConfirmButton: false,
            timer: 1250
        })
    } else {
        Vue.swal({
            position: 'top-end',
            icon: 'success',
            title: message,
            showConfirmButton: false,
            timer: 1250
        })
    }
}

export const ShowErrorMessage = (message) => {
    if (!message) {
        Vue.swal({
            position: 'top-end',
            icon: 'error',
            title: 'An error was encountered while completing your transaction',
            showConfirmButton: false,
            timer: 1250
        })
    } else {
        Vue.swal({
            position: 'top-end',
            icon: 'error',
            title: message,
            showConfirmButton: false,
            timer: 1250
        })
    }
}


export const ShowConfirmDialog = (message) => {
    return new Promise((resolve, reject) => {
        Vue.swal({
            title: 'Are u Sure?',
            text: message,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            cancelButtonText: 'No',
            confirmButtonText: 'Yes',
        }).then((result) => {
            if (result.isConfirmed)
                resolve();
            else
                reject();
        })
    })
}