import React from 'react';
import { View, Text, Image, StyleSheet, TouchableOpacity, Linking } from 'react-native';
import { Ionicons } from '@expo/vector-icons';
import { useNavigation } from '@react-navigation/native';

export default function Welcome() {
  const navigation = useNavigation();

  return (
    <View style={styles.container}>
      <TouchableOpacity style={styles.arrowButton} onPress={() => navigation.navigate('Login')}>
        <Ionicons name="arrow-forward-circle-outline" size={40} color="white" />
      </TouchableOpacity>

      <Image source={require('../assets/logo.png')} style={styles.logo} resizeMode="contain" />

      <View style={styles.contactContainer}>
        <TouchableOpacity onPress={() => Linking.openURL('https://wa.me/553298693858')}>
          <Text style={styles.contactText}>📱 +55 32 9869-3858</Text>
        </TouchableOpacity>

        <TouchableOpacity onPress={() => Linking.openURL('https://www.instagram.com/millenniumbarbearia_')}>
          <Text style={styles.contactText}>📷 @MILLENNIUMBARBEARIA_</Text>
        </TouchableOpacity>

        <TouchableOpacity onPress={() => Linking.openURL('https://maps.google.com/?q=R. Doutor Balbino da Cunha, 35')}>
          <Text style={styles.contactText}>📍 R. Doutor Balbino da Cunha, 35{'\n'}Centro, São João del Rei - MG</Text>
        </TouchableOpacity>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#000',
    alignItems: 'center',
    justifyContent: 'space-between',
    paddingVertical: 80,
  },
  arrowButton: {
    width: 360,
    height: 50,
    justifyContent: 'center',
    alignItems: 'center',
    alignSelf: 'flex-end',
    margin: 20,
  },
  logo: {
    width: 400,
    height: 200,
  },
  contactContainer: {
    alignItems: 'flex-start',
    marginBottom: 20,
  },
  contactText: {
    color: '#fff',
    marginVertical: 5,
    fontSize: 14,
  },
});
