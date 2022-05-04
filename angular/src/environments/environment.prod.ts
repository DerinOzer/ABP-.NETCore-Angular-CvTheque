import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'CvTheque',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44381',
    redirectUri: baseUrl,
    clientId: 'CvTheque_App',
    responseType: 'code',
    scope: 'offline_access CvTheque',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44310',
      rootNamespace: 'Simphonis.CvTheque',
    },
  },
} as Environment;
