import httpClient from '../../../common/HttpClient'
import { INSERT_DEVICE_DETAIL, DELETE_DEVICE_DETAILS } from './actions.type'
import { GET_DEVICE_DETAILS } from './actions.type'
import { SET_DEVICE_DETAILS } from './mutations.type'

const actions = {
    [INSERT_DEVICE_DETAIL](context, payload) {
        return new Promise((resolve, reject) => {
            httpClient.post('/device/insertdevicedetail', payload).then((payload) => {
                resolve(payload)
            }).catch((err) => {
                reject(err)
            })
        })
    },
    [GET_DEVICE_DETAILS](context, payload) {
        return new Promise((resolve, reject) => {
            httpClient.get(`/device/getdevicesensors/${payload}`).then((payload) => {
                context.commit(SET_DEVICE_DETAILS, payload.data);
                resolve(payload);
            }).catch((err) => {
                reject(err);
            })
        })
    },
    [DELETE_DEVICE_DETAILS](context, payload) {
        return new Promise((resolve, reject) => {
            httpClient.delete(`/device/deletedevicesensor/${payload}`).then((payload) => {
                resolve(payload)
            }).catch((err) => {
                reject(err)
            })
        })
    }
}

export default actions;