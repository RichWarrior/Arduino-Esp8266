import httpClient from '../../../common/HttpClient'
import { GET_DEVICE_TYPES } from './actions.type'

import { SET_DEVICE_TYPES } from './mutations.type'

const actions = {
    [GET_DEVICE_TYPES](context) {
        return new Promise((resolve, reject) => {
            httpClient.get('/DeviceType/list').then((payload) => {
                context.commit(SET_DEVICE_TYPES, payload.data)
                resolve(payload)
            }).catch((err) => {
                reject(err);
            })
        })
    }
}

export default actions;