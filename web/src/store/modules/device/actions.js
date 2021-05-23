import httpClient from '../../../common/HttpClient'
import { INSERT_DEVICE, GET_DEVICES, DELETE_DEVICES, GET_DEVICE, UPDATE_DEVICE } from './actions.type'
import { SET_DEVICES, SET_DEVICE } from './mutations.type'

const actions = {
    [INSERT_DEVICE](context, payload) {
        return new Promise((resolve, reject) => {
            httpClient.post('/Device/Insert', payload).then((payload) => {
                resolve(payload)
            }).catch((err) => {
                reject(err);
            })
        })
    },
    [GET_DEVICES](context) {
        return new Promise((resolve, reject) => {
            httpClient.get('/Device/list').then((payload) => {
                context.commit(SET_DEVICES, payload.data);
                resolve(payload)
            }).catch((err) => {
                reject(err);
            })
        })
    },
    [DELETE_DEVICES](context, payload) {
        return new Promise((resolve, reject) => {
            httpClient.delete(`/device/delete/${payload.id}`).then((payload) => {
                resolve(payload)
            }).catch((err) => {
                reject(err);
            })
        })
    },
    [GET_DEVICE](context, payload) {
        return new Promise((resolve, reject) => {
            httpClient.get(`/device/get/${payload.id}`).then((payload) => {
                context.commit(SET_DEVICE, payload.data)
                resolve(payload)
            }).catch((err) => {
                reject(err);
            })
        })
    },
    [UPDATE_DEVICE](context, payload) {
        return new Promise((resolve, reject) => {
            httpClient.put(`/device/update/${payload.Id}`, payload).then((payload) => {
                resolve(payload)
            }).catch((err) => {
                reject(err);
            })
        })
    }
}

export default actions;