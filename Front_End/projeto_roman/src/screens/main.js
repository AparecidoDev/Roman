import React, { Component } from 'react';
import { Image, StyleSheet, View } from 'react-native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

import ProjectList from './projectList';
import ProjectRegister from './projectRegister';

const bottomTab = createBottomTabNavigator();

export default class Main extends Component {

    render() {

        return (

            <View style={styles.main}>

                <bottomTab.Navigator

                    initialRouteName='ProjectList'

                    tabBarOptions={{
                        showLabel: false,
                        showIcon: true,
                        activeBackgroundColor: '#561B75',
                        inactiveBackgroundColor: '#B338F5',
                        activeTintColor: '#FFF',
                        inactiveTintColor: '#FFF',
                        style: { height: 50 }
                    }}
                    screenOptions={({ route }) => ({

                        tabBarIcon: () => {

                            if (route.name === 'ProjectList') {
                                return (
                                    <Image
                                        source={require('../../assets/img/lista.png')}
                                        style={styles.tabBarIcon}
                                    />
                                )
                            }

                            if (route.name === 'ProjectRegister') {
                                return (
                                    <Image
                                        source={require('../../assets/img/cadastro.png')}
                                        style={styles.tabBarIcon}
                                    />
                                )
                            }


                        }
                    })}
                >
                    <bottomTab.Screen name="ProjectList" component={ProjectList} />

                    <bottomTab.Screen name="ProjectRegister" component={ProjectRegister} />

                </bottomTab.Navigator>

            </View>
        );
    }
}

const styles = StyleSheet.create({

    main: {
        flex: 1,
        backgroundColor: '#FFF'
    },

    tabBarIcon: {
        width: 22,
        height: 22
    }

});